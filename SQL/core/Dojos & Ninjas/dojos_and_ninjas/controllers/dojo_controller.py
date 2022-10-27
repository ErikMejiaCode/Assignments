from dojos_and_ninjas import app
from flask import render_template, redirect, request
from dojos_and_ninjas.models.dojo_model import Dojo

@app.route("/")
def index():
    # call the get all classmethod to get all users
    dojos = Dojo.get_all()
    print(dojos)
    return render_template("all_dojos.html", all_dojos = dojos)

@app.route('/create/new', methods=['POST'])
def new_dojo():
    Dojo.new_dojo(request.form)
    return redirect('/')

@app.route('/dojos/<int:id>')
def get_one(id):
    data = {'id' : id}
    dojo = Dojo.one_dojo(data)
    return render_template('one_dojo.html', dojo=dojo)