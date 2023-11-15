import React from "react";
import axios from "axios";
import SearchBar from "./SearchBar";
import UserTable from "./UserTable";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Button from "react-bootstrap/Button";
import Container from "react-bootstrap/esm/Container";
import UserForm from "./UserForm";

const baseURL = "https://localhost:7272/api/HR/v1/";

class FilterableUserTable extends React.Component {
  constructor(props) {
    super(props);
    // FilterableContactTable is the owner of the state as the filterText is needed in both nodes (searchbar and table) that are below in the hierarchy tree.
    this.state = {
      filterText: "",
      showForm: false,
      users: [],
      userInfo:{},
      editable: false,
    };

    this.handleFilterTextInput = this.handleFilterTextInput.bind(this);
    this.setShowForm = this.setShowForm.bind(this);
    this.setShowFormUser = this.setShowFormUser.bind(this);
    this.updateTableData = this.updateTableData.bind(this);
    this.updateTableDataClean = this.updateTableDataClean.bind(this);
  }

  setShowForm() {
    this.setState({ showForm: !this.state.showForm });
    this.setState({ editable: true });
    this.setState({userInfo:{user:{}, addresses:[{}]}});
  }

  setShowFormUser(user, _editable) {

    axios.get(baseURL + "User/"+user.id).then((response) => {
      console.log(response.data)
    this.setState({userInfo:response.data});
    this.setState({ editable: _editable });
    this.setState({ showForm: !this.state.showForm });
    // this.setState({ users: response.data });
    });
  }

  updateTableData() {
    axios.get(baseURL + "Users").then((response) => {
      this.setState({ users: response.data });
      this.setState({ showForm: !this.state.showForm });
    });
  }

  updateTableDataClean() {
    axios.get(baseURL + "Users").then((response) => {
      this.setState({ users: response.data });
      // this.setState({ showForm: !this.state.showForm });
    });
  }

  handleFilterTextInput(filterText) {
    //Call to setState to update the UI
    this.setState({
      filterText: filterText,
    });
    //React knows the state has changed, and calls render() method again to learn what should be on the screen
  }

  componentDidMount() {
    axios.get(baseURL + "Users").then((response) => {
      this.setState({ users: response.data });
    });
  }

  render() {
    return (
      <Container>
        {!this.state.showForm && (
          <div>
            <Row>
              <Col className="col-lg-4">
                <Button
                  as="a"
                  variant="success"
                  style={{ display: "block" }}
                  onClick={this.setShowForm}
                >
                  Add
                </Button>
              </Col>
              <Col className="col-lg-8">
                <SearchBar
                  filterText={this.state.filterText}
                  onFilterTextInput={this.handleFilterTextInput}
                />
              </Col>
            </Row>
            <Row>
              <Col>
                <UserTable
                  users={this.state.users}
                  filterText={this.state.filterText}
                  onSuccess={this.updateTableDataClean}
                  onClick={this.setShowFormUser}
                />
              </Col>
            </Row>
          </div>
        )}
        {this.state.showForm && (
          <Row>
            <Col>
              <div>
                <Row>
                  <UserForm
                    onCancel={this.setShowForm}
                    onSaveSuccess={this.updateTableData}
                    editable = {this.state.editable}
                    userInfo = {this.state.userInfo}
                  ></UserForm>
                </Row>
              </div>
            </Col>
          </Row>
        )}
      </Container>
    );
  }
}

export default FilterableUserTable;
