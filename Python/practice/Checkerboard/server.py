from flask import Flask, render_template  


app = Flask(__name__)


@app.route('/')
def checkerboard():
    return render_template("index.html")

@app.rpute ('/<int:num>')
def eight_by_four(num):
    return render_template("index.html", num=num)


if __name__=="__main__":
    app.run(debug=True)
