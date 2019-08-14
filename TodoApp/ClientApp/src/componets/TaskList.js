import React from 'react';
import { connect } from 'react-redux';
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
        let taskComponentList = this.props.tasks.map(task => (
            <Task {...task} key={task.id} deleteTask={this.deleteTask} />
        ));

        return (
            <React.Fragment>
                {taskComponentList}
                <Form addTask={this.addTask} />
            </React.Fragment>
        );
    }
}

function mapStateToProps(state) {
    return {
        tasks: state.tasks
    };
}

export default connect(mapStateToProps)(TaskList);
