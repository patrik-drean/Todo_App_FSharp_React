import React from 'react';
import { connect } from 'react-redux';
import Task from './Task';
import Form from './Form';
import {ADD_TASK_SAGA, DELETE_TASK_SAGA} from '../actions/actions';

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
        this.props.dispatch({type: DELETE_TASK_SAGA, payload: {id} });
    };

    addTask = taskDescription => {
        this.props.dispatch({type: ADD_TASK_SAGA, payload: {taskDescription} });
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
