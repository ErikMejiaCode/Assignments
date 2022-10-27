from flask import Flask, render_template, request, redirect, session

app = Flask(__name__)
# our index route will handle rendering our form
app.secret_key = 'keep it secret, keep it safe' #secret key is set for security purposes

@app.route('/')
def index():
    return render_template("index.html")


@app.route('/users', methods=['POST'])
def create_user():
    print("Got Post Info")
    #Here we add two prepertoes to session to store the name and email
    session['username'] = request.form['name']
    session['useremail1'] = request.form['email']
    return redirect('/show')

@app.route('/show')
def show_user():
    print("Showing the User info From the Form") 
    print(request.form)
    return render_template("show.html", name_on_template = session['username'], 
    email_on_template = session['useremail1'])


if __name__ == "__main__":
    app.run(debug=True)

