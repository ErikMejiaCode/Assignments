from dojo_survey import app
from flask import render_template, redirect, request, session
from dojo_survey.models.dojo_model import Dojo

@app.route('/')
def index():
    return render_template("index.html")

@app.route('/process_form', methods=['POST'])
def process_form():
    if not Dojo.validate_dojo(request.form):
        Dojo.save(request.form)
        return redirect('/results')
    return redirect('/')

@app.route('/results')
def results():
    return render_template('results.html')