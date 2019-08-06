import React from 'react';
import Task from './Task';
import Form from './Form';

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
        .then(res => res.text())
        .then(res => console.log(res))

      this.setState({ tasks: updatedTasks });
    };

    let addTask = taskDescription => {
      let tasks = this.state.tasks;
      let newTask = { id: tasks.length + 1, description: taskDescription };
      this.setState({ tasks: [...tasks, newTask] });
    };

    // let editTask = (idToEdit) => {
    //     let updatedTasks = this.state.tasks.filter(function (task) {
    //         if (task.id !== idToEdit) {

    //         }
    //     });

    //     this.setState({tasks: updatedTasks});
    // }

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
