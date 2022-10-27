from flask import Flask, render_template

app = Flask(__name__)    # Create a new instance of the Flask class called "app"


@app.route('/')          # The "@" decorator associates this route with the function immediately following
def home_page():
    return "<h1>Playground Assignment</h1"

@app.route('/play')          # The "@" decorator associates this route with the function immediately following
def level_1():
    return render_template("index.html", number=3)


@app.route('/play/<int:number>')
def level_2(number):
    return render_template("index2.html", number=number)


@app.route('/play/<int:number>/<string:different_color>')
def level_3(number, different_color):
    colorChange = different_color
    return render_template("index3.html", number=number, colorChange=colorChange)


if __name__=="__main__":   # Ensure this file is being run directly and not from a different module
    app.run(debug=True)    # Run the app in debug mode.
    # app.run(debug=True, host='0.0.0.0')    # to run on local router

