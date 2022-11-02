import './App.css';
import { useState } from 'react';
// import Display from './components/Display';
import Box from './components/Box';
import Form from './components/Form';

function App() {

  //creating State
  const [boxes, setBoxes] = useState([
    {color: "red"},
    {color: "green"},
    {color: "blue"}
  ]);

  const addBoxColor = (colorName) => {
    //add the color name we got from Form component to the boxes array
    setBoxes([...boxes, colorName]);
  }

  return (
    <div className="App">
      <h1>Boxes 📦</h1>
      <hr />
      <Form addBoxColor={addBoxColor}/>
      {/* <Display boxes={boxes}/> */}

      {boxes.map((eachBox, index) => {
        return <Box key={index} boxObj={eachBox}/>
      })}
    </div>
  );
}

export default App;
