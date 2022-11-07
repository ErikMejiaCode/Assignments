const Joke = require('../models/jokes.model')

//RESPONSIBLE FOR FULL CRUD

//Get ALL Jokes
module.exports.getAllJokes = (req, res) => {
    Joke.find()
        .then(allDaJokes => res.json({ jokes: allDaJokes }))
        .catch(err => res.json({ message: 'Something went wrong', error: err }));
}

//Get ONE joke
module.exports.findOneSingleJoke= (req, res) => {
    Joke.findOne({ _id: req.params.id })
        .then(oneSingleJoke => res.json({ joke: oneSingleJoke}))
        .catch(err => res.json({ message: 'Something went wrong', error: err }));
}

//CREATE ONE Joke
module.exports.createNewJoke = (req, res) => {
    Joke.create(req.body)
        .then(newlyCreatedJoke => res.json({ joke: newlyCreatedJoke }))
        .catch(err => res.json({ message: 'Something went wrong', error: err }));
}

//UPDATE Joke
module.exports.updateExistingJoke = (req, res) => {
    Joke.findOneAndUpdate(
        { _id: req.params.id },
        req.body,
        { new: true, runValidators: true }
    )
        .then(newlyUpdatedJoke => res.json({ joke: newlyUpdatedJoke }))
        .catch(err => res.json({ message: 'Something went wrong', error: err }));
}

//DELETE Joke
module.exports.deleteAnExistingJoke = (req, res) => {
    Joke.deleteOne({ _id: req.params.id })
        .then(result => res.json({ result: result }))
        .catch(err => res.json({ message: 'Something went wrong', error: err }));
}

//Random Joke 
