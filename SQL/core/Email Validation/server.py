from flask_app import app
from flask_app.controllers import email_controller
# from flask_app.controllers import surveys

if __name__=="__main__":
    app.run(debug=True)