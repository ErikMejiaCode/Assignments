from crypt import methods
from dojos_and_ninjas import app
from flask import render_template, redirect, request
from dojos_and_ninjas.models.dojo_model import Dojo
from dojos_and_ninjas.models.ninja_model import Ninja

@app.route('/ninja/new')
def new_ninja():
    all_dojos = Dojo.get_all()
    return render_template('ninja_new.html', all_dojos=all_dojos)

@app.route('/ninja/create', methods=['POST'])
def create_ninja():
    Ninja.create(request.form)
    return redirect(f'/dojos/{request.form["dojo_id"]}')
