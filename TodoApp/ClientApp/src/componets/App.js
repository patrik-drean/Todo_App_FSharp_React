import React from 'react';
import '../styles/App.css';
import TaskList from './TaskList';

const appStyle = {
  padding: '20px',
  backgroundColor: '#171717',
  height: '100vh'
};

class App extends React.Component {
  render() {
    return (
      <div className="App" style={appStyle}>
        <TaskList />
      </div>
    );
  }
}

export default App;
