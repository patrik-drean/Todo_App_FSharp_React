import React from 'react';
import Task from './Task';
import Form from './Form';

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

  render() {
    let deleteTask = idToDelete => {
      let updatedTasks = this.state.tasks.filter(task => {
        return task.id !== idToDelete;
      });

      this.setState({ tasks: updatedTasks });
    };

    let addTask = taskDescription => {
      let tasks = this.state.tasks;
      let newTask = { id: tasks.length, description: taskDescription };
      console.log('new task', newTask);
      //   console.log(tasks.push(newTask));
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
