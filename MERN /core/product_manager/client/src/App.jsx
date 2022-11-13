import './App.css';
import {Navigate, Route, Routes} from "react-router-dom"
// import {AllProducts} from "./views/AllProducts"
import {NewProduct} from "./views/NewProduct"
import {EditProduct} from "./views/EditProduct"
import {OneProduct} from "./views/OneProduct"
import {NotFound} from "./views/NotFound"


function App() {
  return (
    <div className="container">
      <h4 className='text-center mt-2'>Product Manager</h4>


      <Routes>
        <Route path='/' element={<Navigate to = '/products/new' replace/>} />
        <Route path='/products' element={<Navigate to = '/products/new' replace/>} />
        <Route path='/products/edit/:id' element={<EditProduct />} />
        <Route path='/products/:id' element={<OneProduct />} />
        <Route path='/products/new' element={<NewProduct />} />
        <Route path='*' element={<NotFound />} />
      </Routes> 

    </div>


  );
}

export default App;
