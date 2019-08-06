import React from 'react'
import ParcelService from './parcelService'
import { DndProvider } from 'react-dnd'
import HTML5Backend from 'react-dnd-html5-backend'
import './App.css';

function App() {
  return (
    <div className="App">
      <DndProvider backend={HTML5Backend}>
        <ParcelService />
      </DndProvider>
    </div>
  )
}

export default App;
