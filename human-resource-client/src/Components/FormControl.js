import React from "react";
import Form from "react-bootstrap/Form";

class FormControl extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <Form.Group className="mb-3" controlId={this.props.controlId}>
        <Form.Label>{this.props.label}</Form.Label>
        <Form.Control placeholder={this.props.placeholder} value= {this.props.value} name={this.props.name} onChange={this.props.onChange}/>
      </Form.Group>
    );
  }
}

export default FormControl;
