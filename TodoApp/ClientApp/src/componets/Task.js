import React from 'react';

const taskWrapperStyle = {
    backgroundColor: "#ffffce",
    height: "60px",
    width: "40%",
    margin: "10px auto",
    border: "5px solid #fcfcb0",
    fontFamily: "Georgia",
    fontSize: "15pt",
}

class Task extends React.Component {

    render() {
        return (
            <div 
                onClick={() => this.props.deleteTask(this.props.id)}
                style={taskWrapperStyle}
            >
                <p>
                    Task {this.props.id}: {this.props.description}
                </p>
            </div>
        );
    }
}

export default Task;