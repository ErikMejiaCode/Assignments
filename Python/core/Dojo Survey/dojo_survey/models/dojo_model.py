from dojo_survey.config.mysqlconnection import MySQLConnection, connectToMySQL
from dojo_survey import DATABASE
from flask import flash

class Dojo:
    def __init__(self, data):
        self.id = data['id']
        self.name = data['name']
        self.location = data['location']
        self.language = data['language']
        self.comment = data['comment']
        self.created_at = data['created_at']
        self.updated_at = data['updated_at']
    # Now we use class methods to query our database

    @classmethod
    def save(cls, data):
        query = "INSERT INTO dojos (name, location, language, comments) VALUES (%(name)s,%(location)s,%(language)s,%(comment)s);"
        return MySQLConnection(DATABASE).query_db(query, data)

    # @classmethod
    # def get_last_dojo(cls):
    #     query = "SELECT * FROM dojos ORDER BY dojos.id DESC LIMIT 1;"
    #     results = connectToMySQL(DATABASE).query_db(query)
    #     return Dojo(results[0])


    @staticmethod
    def validate_dojo(dojo):
        is_valid = True
        if len(dojo['name']) < 2:
            is_valid = False
            flash("Name must be at least 3 characters.")
        return is_valid
    def validate_dojo(dojo):
        is_valid = True
        if len(dojo['location']) < 1:
            is_valid = False
            flash("Must be a dojo location.")
        return is_valid
    def validate_dojo(dojo):
        is_valid = True
        if len(dojo['language']) < 1:
            is_valid = False
            flash("Must choose a favorite language.")
        return is_valid
    def validate_dojo(dojo):
        is_valid = True
        if len(dojo['comment']) < 3:
            flash("Comment must be at least 4 characters.")
            is_valid = False
        return is_valid
    