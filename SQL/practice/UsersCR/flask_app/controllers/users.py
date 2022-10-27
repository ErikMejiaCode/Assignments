from flask_app import app
from flask import render_template,redirect,request,session,flash
from flask_app.models.user import User

@app.route("/")
def index():
    # call the get all classmethod to get all users
    users = User.get_all()
    print(users)
    return render_template("read_all.html", all_users = users)

@app.route('/create_user')
def create_user_form():
    return render_template('create_user.html')

@app.route('/create/result', methods=['POST'])
def create_user():
    User.save(request.form)
    return redirect('/')

@app.route('/show_user/<int:id>')
def show_user_detail(id):
    data = {
        "id":id
    }
    return render_template('show_user.html', user=User.get_user(data))

@app.route('/edit_user/<int:id>')
def edit(id):
    data = {
        "id":id
    }
    user = User.get_user(data)
    return render_template("edit_user.html", user=user)


@app.route('/user/update/<int:id>', methods=['POST'])
def update(id):
    data = {
        # 'first_name': request.form['first_name']
        **request.form,
        'id': id
    }
    User.update(data)
    return redirect('/')

@app.route('/user/destroy/<int:id>')
def destroy(id):
    data = {
        'id':id
    }
    User.delete_user(data)
    return redirect('/')