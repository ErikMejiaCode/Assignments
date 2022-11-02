import style from './App.css';
import { useState } from 'react';

function App() {

  const [pokemon, setPokemon] = useState([]);

  const fetchPokemon = () => {
    fetch("https://pokeapi.co/api/v2/pokemon?limit=807&offset=0")
      .then((res) => {
        return res.json()
      })
      .then((res) => {
        console.log(res.results)
        setPokemon(res.results)
      })
      .catch((err) => {
        console.log("ERROR", err)
      })
  }


  return (
    <div className="container">
      <div className="App">
        <h1>Pokemon API 🐢 🐉 🐀 🧅</h1>
        <hr />

        <button onClick={fetchPokemon} >Fetch Pokemon</button>
        <p></p>

        <table className={style.table}>
          <thead>
            <tr>
              <th>Pokemon Name</th>
            </tr>
          </thead>
          <tbody>
            {
              pokemon.map((onePokemon, index) => {
                return (
                  <tr>
                  <td>{onePokemon.name}</td>
                  </tr>
                )
              })
            }
          </tbody>
        </table>

      </div>
    </div>
  );
}

export default App;
