from dojo_survey import app
from flask import render_template, request, redirect, session
from dojo_survey.controllers import dojo_controller

if __name__ == "__main__":
    app.run(debug=True, port = 8000)

