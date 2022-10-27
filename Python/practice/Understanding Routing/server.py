from flask import Flask, render_template

app = Flask(__name__)


@app.route("/")
def index():
    return "Hello World!"

@app.route("/dojo")
def dojo():
    return "Dojo!"

@app.route("/say/<string:name>")
def say(name):
    print("I got the name," + name)
    return f"Hi {name}!"

@app.route ("/repeat/<int:number>/<string:word>")
def repeat(number, word):
    return word * number

if __name__ == "__main__":
    app.run(debug=True)