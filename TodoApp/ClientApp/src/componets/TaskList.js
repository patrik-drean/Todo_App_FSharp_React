import React from 'react';
import { createStore } from 'redux';
import { Provider } from 'react-redux';
import Task from './Task';
import Form from './Form';

const initialState = {
  tasks: []
};

function reducer(state = initialState, action) {
  switch (action.type) {
    case 'ADD_TASK':
      return {
        tasks: ['hi']
      };
    default:
      return state;
  }
}

const store = createStore(reducer);
store.dispatch({
  type: 'ADD_TASK',
  task: { id: 8, description: 'from store' }
});

class TaskList extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      tasks: []
    };

    fetch('api/Tasks')
      .then(response => response.json())
      .then(data => {
        this.setState({ tasks: data, loading: false });
      });
  }
  deleteTask = id => {
    let updatedTasks = this.state.tasks.filter(task => {
      return task.id !== id;
    });

    fetch(`api/Tasks/${id}`, {
      method: 'DELETE',
      headers: { 'Content-Type': 'application/json' }
    });

    this.setState({ tasks: updatedTasks });
  };

  addTask = taskDescription => {
    let tasks = this.state.tasks;
    let newTask = { id: tasks.length + 1, description: taskDescription };
    this.setState({ tasks: [...tasks, newTask] });

    fetch(`api/Tasks/`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(newTask)
    });
  };

  render() {
    let taskComponentList = this.state.tasks.map(task => (
      <Task {...task} key={task.id} deleteTask={this.deleteTask} />
    ));

    return (
      <Provider store={store}>
        {taskComponentList}
        <Form addTask={this.addTask} />
      </Provider>
    );
  }
}

export default TaskList;
