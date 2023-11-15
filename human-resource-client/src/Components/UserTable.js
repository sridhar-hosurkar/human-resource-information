import React from 'react';
import UserRow from "./UserRow"
import Table from 'react-bootstrap/Table';

class UserTable extends React.Component {
  constructor(props){
    super(props);
    this.state = {
      onDeleteSuccess:this.props.onSuccess,
      onClick:this.props.setShowFormUser
    }
    this.setForm = this.setForm.bind(this);
  }
  setForm(user, editable){
    this.props.onClick(user, editable)
  }
    render() {
      var rows = [];
      this.props.users.forEach((user) => {
        if ((user.firstName.indexOf(this.props.filterText) === -1) && user.lastName.indexOf(this.props.filterText) === -1) {
          return;
        }
        rows.push(<UserRow key={user.id} user={user} onDeleteSuccess={this.state.onDeleteSuccess} onClick={this.setForm}/>);
      });
      return (
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>Name</th>
              <th>Phone</th>
              <th>Email</th>
              <th></th>
              <th></th>
              <th></th>
            </tr>
          </thead>
          <tbody>{rows}</tbody>
        </Table>
      );
    }
  }

  export default UserTable;