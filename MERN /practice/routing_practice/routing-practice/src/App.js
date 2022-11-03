import './App.css';
import {Link, Navigate, Route, Routes} from 'react-router-dom';
import {WordOrNumber} from './views/WordOrNumber';
import {Color} from './views/Color';
import {Home} from './views/Home';

function App() {
  return (
    <>
      <div>
        <header>
          <nav>
            <Link to="/home">Home</Link>
          </nav>
        </header>

      <Routes>
        <Route path="/" element={<Navigate to="/home" replace/>} />
        <Route path="/home" element={<Home />} />
        <Route path="/:num" element={<WordOrNumber />} />
        <Route path="/:num/:color/:background" element={<Color />} />
      </Routes>
  
      </div>
    </>
  );
}

export default App;
