from crypt import methods
from flask_app import app
from flask import render_template, redirect, session, flash, request
from flask_app.models.user_model import User
from flask_app.models.recipe_model import Recipe

@app.route('/recipes/new')
def new_recipe_form():
    return render_template('recipe_new.html')

@app.route("/recipes/create", methods=['POST'])
def create_recipe():
    if 'user_id' not in session:
        return redirect('/')
    if not Recipe.validator(request.form):
        return redirect('/recipes/new')
    data = {
        "name" : request.form['name'],
        "description" : request.form['description'],
        "instructions" : request.form['instructions'],
        "date" : request.form['date'],
        "time" : request.form['time'],
        "user_id" : session['user_id']
    }
    Recipe.create(data)
    return redirect('/dashboard')

@app.route('/recipes/<int:id>')
def one_recipe(id):
    if 'user_id' not in session:
        return redirect('/')
    user_data = {
        'id' : session['user_id']
    }
    logged_user = User.get_by_id(user_data)
    this_recipe = Recipe.get_by_id({'id' : id})
    return render_template('recipe_one.html', this_recipe=this_recipe, logged_user=logged_user)
    

@app.route('/recipes/<int:id>/edit')
def edit_recipe(id):
    if 'user_id' not in session:
        return redirect('/')
    this_recipe = Recipe.get_by_id({'id' : id})
    return render_template('recipe_edit.html', this_recipe=this_recipe)

@app.route('/recipes/<int:id>/update', methods=['POST'])
def update_recipe(id):
    if not Recipe.validator(request.form):
        return redirect(f'/recipes/{id}/edit')
    recipe_data = {
        **request.form, 
        'id' : id
    }
    Recipe.update(recipe_data)
    return redirect('/dashboard')

@app.route('/recipes/<int:id>/delete')
def delete_recipes(id):
    this_recipe = Recipe.get_by_id({'id' : id})
    if not this_recipe.user_id == session['user_id']:
        flash("You can't remove a recipe you did not add")
        return redirect('/dashboard')
    Recipe.delete({'id' : id})
    return redirect('/dashboard')