from unittest import result
from flask_app.config.mysqlconnection import connectToMySQL
from flask_app import DATABASE
from flask import flash
from flask_app.models import user_model

class Recipe:
    def __init__(self, data):
        self.id = data['id']
        self.name = data['name']
        self.description = data['description']
        self.instructions = data['instructions']
        self.date = data['date']
        self.time = data['time']
        self.created_at = data['created_at']
        self.updated_at = data['updated_at']
        self.user_id = data['user_id']

#query used to insert or add new instance into the database. 
    @classmethod
    def create(cls, data):
        query = "INSERT INTO recipes (name, description, instructions, date, time, user_id) VALUES (%(name)s, %(description)s, %(instructions)s, %(date)s, %(time)s, %(user_id)s);"
        return connectToMySQL(DATABASE).query_db(query, data)

#JOIN method used to get all instances
    @classmethod
    def get_all(cls):
        query = "SELECT * FROM recipes JOIN users ON recipes.user_id = users.id"
        results = connectToMySQL(DATABASE).query_db(query)
        if len(results) > 0:
            all_recipes = []
            for row in results:
                this_recipe = cls(row)
                user_data = {
                    **row, 
                    "id" : row['users.id'],
                    "created_at" : row['users.created_at'],
                    "updated_at" : row['users.updated_at']
                }
                this_user = user_model.User(user_data)
                this_recipe.cook = this_user
                all_recipes.append(this_recipe)
            return all_recipes
        return []

# classmethod used in order to get 1 employee by their ID 
    @classmethod
    def get_by_id(cls, data):
        query = "SELECT * FROM recipes JOIN users ON recipes.user_id = users.id WHERE recipes.id = %(id)s"
        results = connectToMySQL(DATABASE).query_db(query, data)
        if len(results) < 1:
            return False
        row = results[0]
        this_recipe = cls(row)
        user_data = {
            **row, 
            "id" : row['users.id'],
            "created_at" : row['users.created_at'],
            "updated_at" : row['users.updated_at']
        }
        this_user = user_model.User(user_data)
        this_recipe.cook = this_user
        return this_recipe

#classmethod used to update existing rows within the database
    @classmethod
    def update(cls, data):
        query = "UPDATE recipes SET name = %(name)s, description = %(description)s, instructions = %(instructions)s, date = %(date)s, time = %(time)s WHERE id = %(id)s"
        return connectToMySQL(DATABASE).query_db(query, data)

#classmethod used to delete existing rows within the database
    @classmethod
    def delete(cls, data):
        query = "DELETE FROM recipes WHERE id = %(id)s"
        return connectToMySQL(DATABASE).query_db(query, data)

#logic used for validating information entered or not entered into the form. requires import of flash & the correct items within the HTML page to display.
    @staticmethod
    def validator(form_data):
        is_valid = True
        if len(form_data['name']) < 2:
            flash("Name of recipe required.")
            is_valid = False
        if len(form_data['description']) < 2:
            flash("Description of recipe required.")
            is_valid = False
        if len(form_data['instructions']) < 2:
            flash("Instructions for recipe required.")
            is_valid = False
        if len(form_data['date']) < 2:
            flash("Date required.")
            is_valid = False
        if "time" not in form_data:
            flash("Under 30min required.")
            is_valid = False
        return is_valid
