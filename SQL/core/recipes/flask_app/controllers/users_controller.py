from flask_app import app
from flask import render_template, redirect, session, flash, request
from flask_app.models.user_model import User
from flask_bcrypt import Bcrypt
from flask_app.models.recipe_model import Recipe
bcrypt = Bcrypt(app)


@app.route('/')
def landing():
    return render_template('index.html') 

@app.route('/dashboard')
def dashboard():
    if not 'user_id' in session:
        return redirect('/')
    user_data = {
        'id' : session['user_id']
    }
    logged_user = User.get_by_id(user_data)
    all_recipes = Recipe.get_all()
    return render_template('dashboard.html', logged_user=logged_user, all_recipes=all_recipes)

@app.route('/users/register', methods=['POST'])
def reg_user():
    if not User.validator(request.form):
        return redirect('/')
    hash_browns = bcrypt.generate_password_hash(request.form['password'])
    data = {
        **request.form,
        'password' : hash_browns
    }
    new_id = User.create(data)
    session['user_id'] = new_id
    return redirect('/dashboard')


@app.route('/users/login', methods=['POST'])
def log_user():
    data = {
        'email' : request.form['email']
    }
    user_in_db = User.get_by_email(data)
    if not user_in_db:
        flash("Invalid Credentials", "log")
        return redirect('/')
    if not bcrypt.check_password_hash(user_in_db.password, request.form['password']):
        flash("Invalid Credentials**", "log")
        return redirect("/")
    session['user_id'] = user_in_db.id
    return redirect("/dashboard")

@app.route("/users/logout")
def log_out_user():
    del session['user_id']
    return redirect('/')