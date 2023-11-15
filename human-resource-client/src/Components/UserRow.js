import React from "react";
import axios from "axios";
import Button from "react-bootstrap/Button";

const baseURL = "https://localhost:7272/api/HR/v1/";
class UserRow extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      onDeleteSuccess: this.props.onDeleteSuccess,
      onClick: this.props.onClick
    };
    this.deleteUser = this.deleteUser.bind(this);
    this.setFormEdit = this.setFormEdit.bind(this);
    this.setFormView = this.setFormView.bind(this);
  }
  setFormEdit(){
    this.props.onClick(this.props.user, true);
  }

  setFormView(){
    this.props.onClick(this.props.user, false);
  }

  deleteUser() {
    axios
      .delete(`${baseURL}User/${this.props.user.id}`)
      .then(() => {
        this.state.onDeleteSuccess();
      })
      .catch((error) => {
        console.log(error);
      });
  }
  render() {
    return (
      <tr>
        <td>
          {this.props.user.firstName} {this.props.user.lastName}
        </td>
        <td>{this.props.user.phone}</td>
        <td>{this.props.user.email}</td>
        <td>
          <Button
            as="a"
            variant="success"
            user={this.props.user}
            onClick={this.setFormView}
          >
            Details
          </Button>
        </td>
        <td>
          <Button
            as="a"
            variant="primary"
            user={this.props.user}
            onClick={this.setFormEdit}
          >
            Edit
          </Button>
        </td>
        <td>
          <Button as="a" variant="danger" onClick={this.deleteUser}>
            Delete
          </Button>
        </td>
      </tr>
    );
  }
}

export default UserRow;
