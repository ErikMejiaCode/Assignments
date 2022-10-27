from flask_app import app
from flask import render_template, request, redirect
from flask_app.models.email_model import Email


@app.route('/')
def index():
    return render_template('index.html')

@app.route('/create', methods=['POST'])
def create():
    if not Email.is_valid(request.form):
        return redirect('/')
    Email.create(request.form)
    return redirect ('/results')

@app.route('/results')
def success():
    return render_template('success.html', emails = Email.get_all())

@app.route('/delete/<int:id>')
def delete(id):
    data = {'id' : id}
    email = Email.delete(data)
    return redirect('/results')