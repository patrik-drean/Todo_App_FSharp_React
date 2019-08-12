import React from 'react';
import { createStore } from 'redux';
import Task from './Task';
import Form from './Form';

function reducer(state, action) {
    return state;
}

const store  = createStore(reducer);

class TaskList extends React.Component {
 

  constructor(props) {
    super(props);

    this.state = {
      tasks: []
    };

    let response = fetch('api/Tasks')
        .then(response => response.json())
        .then(data => {
          this.setState({ tasks: data, loading: false });
    });
    
  }

  render() {
    let deleteTask = id => {
      let updatedTasks = this.state.tasks.filter(task => {
        return task.id !== id;
      });

        fetch(`api/Tasks/${id}`, {
          method: 'DELETE',
          headers: {'Content-Type': 'application/json'}
        })

      this.setState({ tasks: updatedTasks });
    };

    let addTask = taskDescription => {
      let tasks = this.state.tasks;
      let newTask = { id: tasks.length + 1, description: taskDescription };
        this.setState({ tasks: [...tasks, newTask] });

        fetch(`api/Tasks/`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newTask)

        })
    };

    let taskComponentList = this.state.tasks.map(task => (
      <Task {...task} key={task.id} deleteTask={deleteTask} />
    ));

    return (
      <React.Fragment>
        {taskComponentList}
        <Form addTask={addTask} />
      </React.Fragment>
    );
  }
}

export default TaskList;
