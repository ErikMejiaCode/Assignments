from flask import Flask, render_template, request, redirect, session

app = Flask(__name__)
# our index route will handle rendering our form
app.secret_key = 'keep it secret, keep it safe'

@app.route('/')
def index():
    if "count" not in session:
        session["count"] = 1
    else:
        session["count"] += 1

    return render_template("index.html")

@app.route('/app_count', methods=['POST'])
def app_count():
    if request.form["btn_1"] == "add_1":
        session["count"] += 1
    elif request.form["btn_1"] == "reset":
        session["count"] = 0

    return redirect('/')

@app.route('/destroy_session')
def destroy_session():
    session.clear()
    return redirect('/')

if __name__ == "__main__":
    app.run(debug=True)

