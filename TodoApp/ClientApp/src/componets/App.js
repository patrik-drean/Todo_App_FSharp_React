import React from 'react';
import { createStore } from 'redux';
import { Provider } from 'react-redux';
import '../styles/App.css';
import '../sagas/sagas.js';
import TaskList from './TaskList';

const appStyle = {
    padding: '20px',
    backgroundColor: '#171717',
    height: '100vh'
};

const initialState = {
    tasks: [{ id: 1, description: 'Hardcoded Value' }]
};

function reducer(state = initialState, action) {
    switch (action.type) {
        case 'ADD_TASK':
            const nextId = state.tasks[state.tasks.length-1].id + 1; //TODO
            const newTask = { id: nextId, description: action.payload.taskDescription };
            
            
            return {
                tasks: [...state.tasks, newTask]
            };
        case 'DELETE_TASK':
            let updatedTasks = state.tasks.filter(task => {
                return task.id !== action.payload.id;
            });

            fetch(`api/Tasks/${action.payload.id}`, {
                method: 'DELETE',
                headers: { 'Content-Type': 'application/json' }
            });

            return {
                tasks: updatedTasks
            };
        default:
            return state;
    }
}

const store = createStore(reducer);

class App extends React.Component {
    render() {
        return (
            <Provider store={store}>
                <div className="App" style={appStyle}>
                    <TaskList />
                </div>
            </Provider>
        );
    }
}

export default App;
