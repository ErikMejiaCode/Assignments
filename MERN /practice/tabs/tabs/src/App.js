import './App.css';
import React, { useState } from 'react';
import TabWrapper from './components/TabWrapper';

function App() {

  const [tabs, setTabs] = useState([
    {
        name: "tab1",
        message: "Tab 1 content is showing here",
        isSelected: true
    },
    {
        name: "tab2",
        message: "Tab 2 content is showing here",
        isSelected: false
    },
    {
        name: "tab3",
        message: "Tab 3 content is showing here",
        isSelected: false
    }
])

  return (
    <>
      <TabWrapper tabs={tabs} setTabs={setTabs}/>
    </>
  );
}

export default App;
