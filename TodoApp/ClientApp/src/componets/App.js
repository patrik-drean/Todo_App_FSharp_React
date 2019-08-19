import React from 'react';
import { createStore, applyMiddleware } from 'redux'
import createSagaMiddleware from 'redux-saga'
import { Provider } from 'react-redux';
import '../styles/App.css';
import TaskList from './TaskList';
import reducer from '../reducers/reducers.js';
import rootSaga from '../sagas/sagas.js';

const appStyle = {
    padding: '20px',
    backgroundColor: '#171717',
    height: '100vh'
};

const sagaMiddleware = createSagaMiddleware();
const store = createStore(
    reducer,
    applyMiddleware(sagaMiddleware)
);
sagaMiddleware.run(rootSaga);

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
