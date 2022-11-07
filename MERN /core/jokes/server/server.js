const express = require('express')
const app = express();
const PORT = 8000;
const DB = "jokes"

//middleware
// make sure these lines are above any app.get or app.post code blocks
app.use( express.json() );
app.use( express.urlencoded({ extended: true }) );

//Connect to Mongoose
require("./config/mongoose.config")(DB)

//Modularize Routes
require("./routes/jokes.routes")(app)





app.listen(PORT, () => console.log(`🎈🎈🎈Up on PORT ${PORT}`))