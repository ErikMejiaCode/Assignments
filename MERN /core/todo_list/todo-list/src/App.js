import './App.css';
import React, { useState } from 'react';
import Todo from './components/Todo';

function App() {
  const [newTodo, setNewTodo] = useState('');
  const [todos, setTodos] = useState([]);



  const handleNewTodoSubmit = (event) => {
    event.preventDefault();

    if (newTodo.length === 0) {
      return;
    }

    const todoItem = {
      text: newTodo,
      complete: false
    }

    setTodos([...todos, todoItem])
    setNewTodo("");
  }

  const handleTodoDelete = (delIdx) => {
    const filteredTodos = todos.filter((_todo, i) => {
      return i !== delIdx;
    });
    setTodos(filteredTodos)
  }

  const handleToggleComplete = (idx) => {
    const updatedTodos = todos.map((todo, index) => {
      if (idx === index) {
        todo.complete = !todo.complete;
      }
      return todo
    })
    setTodos(updatedTodos)
  }


  return (
    <div style={{ textAlign: "center", marginTop: "10px" }}>
      <form onSubmit={(event) => {
        handleNewTodoSubmit(event)
      }}>
        <input onChange={(event) => {
          setNewTodo(event.target.value)
        }} value={newTodo} type="text" />
        <div>
          <p></p>
          <button>Add</button>
        </div>
      </form>

      <hr />

      {
        todos.map((todo, index) => {
          return <Todo key={index} todo={todo} 
          handleToggleComplete={handleToggleComplete} 
          index={index} 
          handleTodoDelete={handleTodoDelete}/>
        })}
    </div>
  );
}

export default App;
