import './App.css';
import { Routes, Route, Link} from 'react-router-dom';
import Form from './components/Form';
import People from './components/People';
import Planet from './components/Planet';
import ErrorPage from './components/ErrorPage';


function App() {
  return (
    <div className="App">
      <Link to="/">Home</Link>

      <Routes>
        <Route path="/" element={<Form/>} />
        <Route path="/people/:id" element={<People/>} />
        <Route path="/planet/:id" element={<Planet/>} />
        <Route path="*" element={<ErrorPage/>} />
      </Routes>

    </div>

  );
}

export default App;
