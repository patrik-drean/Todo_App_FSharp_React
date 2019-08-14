import React from 'react';
import { createStore } from 'redux';
import { Provider } from 'react-redux';
import '../styles/App.css';
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
            return {
                tasks: []
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
