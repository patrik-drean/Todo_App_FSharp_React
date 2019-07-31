import React from 'react';

const inputStyle = {
  width: '300px',
  height: '30px',
  display: 'block',
  margin: '20px auto 10px auto',
  fontSize: '15pt'
};

const submitButtonStyle = {
  width: '150px',
  display: 'block',
  margin: '10px auto',
  fontSize: '12pt',
  MozBoxShadow: 'inset 0px 1px 0px 0px #bee2f9',
  WebkitBoxShadow: 'inset 0px 1px 0px 0px #bee2f9',
  boxShadow: 'inset 0px 1px 0px 0px #bee2f9',
  background: 'linear-gradient(to bottom, #63b8ee 5%, #468ccf 100%)',
  filter:
    "progid:DXImageTransform.Microsoft.gradient(startColorstr='#63b8ee', endColorstr='#468ccf',GradientType=0)",
  backgroundColor: '#63b8ee',
  MozBorderRadius: '6px',
  WebkitBorderRadius: '6px',
  borderRadius: '6px',
  border: '1px solid #3866a3',
  cursor: 'pointer',
  color: 'white',
  fontFamily: 'Arial',
  fontWeight: 'bold',
  padding: '6px 24px',
  textDecoration: 'none',
  textShadow: '0px 1px 0px #7cacde'
};

class Form extends React.Component {
  constructor(props) {
    super(props);
    this.state = {taskValue: ""};
    
    this.handleTaskChange = this.handleTaskChange.bind(this);
  }
  
  handleTaskChange(event) {
    this.setState({taskValue: event.target.value});
  }
  
  render() {
    return (
      <form>
        <input value={this.state.taskValue} 
               onChange={this.handleTaskChange}
               style={inputStyle} />
        <button
          onClick={event => {
            event.preventDefault();
            this.props.addTask(this.state.taskValue);
          }}
          style={submitButtonStyle}
        >
          Add Task
        </button>
      </form>
    );
  }
}

export default Form;
