from dojos_and_ninjas import app
from flask import render_template, redirect, request
from dojos_and_ninjas.controllers import dojo_controller, ninja_controller

if __name__ == "__main__":
    app.run(debug=True)