import React from "react";
import axios from "axios";
import Form from "react-bootstrap/Form";
import FormControl from "./FormControl";
import Row from "react-bootstrap/esm/Row";
import Col from "react-bootstrap/esm/Col";
import Button from "react-bootstrap/Button";
import Alert from "react-bootstrap/Alert";
const baseURL = "https://localhost:7272/api/HR/v1/";

class UserForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      ErrorMessage: [],
      onSaveSuccess: this.props.onSaveSuccess,
      onCancel: this.props.onCancel,
      userId: this.props.userInfo.user.id, // | "",
      firstName: this.props.userInfo.user.firstName, // | "",
      lastName: this.props.userInfo.user.lastName, // | "",
      email: this.props.userInfo.user.email, // | "",
      phone: this.props.userInfo.user.phone, // | "",
      addressId: this.props.userInfo.addresses[0].id, // | "",
      doorNo: this.props.userInfo.addresses[0].doorNo,
      streetName: this.props.userInfo.addresses[0].streetName,
      city: this.props.userInfo.addresses[0].city,
      state: this.props.userInfo.addresses[0].state,
      country: this.props.userInfo.addresses[0].country,
      postCode: this.props.userInfo.addresses[0].postCode,
      editable: this.props.editable,
    };
    console.log(this.props.userInfo);
    console.log(this.props.userInfo.addresses[0].postcode);
    this.onChange = this.onChange.bind(this);
  }

  onChange(e) {
    this.setState({
      [e.target.name]: e.target.value,
    });
  }

  handleSubmit = (event) => {
    console.log("here");
    let userInfo = JSON.stringify({
      user: {
        id: this.state.userId,
        firstName: this.state.firstName,
        lastName: this.state.lastName,
        email: this.state.email,
        phone: this.state.phone,
      },
      addresses: [
        {
          id: this.state.addressId,
          doorNo: this.state.doorNo,
          streetName: this.state.streetName,
          city: this.state.city,
          state: this.state.state,
          country: this.state.country,
          postCode: this.state.postCode,
        },
      ],
    });
    console.log(userInfo);
    axios
      .post("https://localhost:7272/api/HR/v1/User", userInfo, {
        headers: {
          // Overwrite Axios's automatically set Content-Type
          "Content-Type": "application/json",
        },
      })
      .then((response) => {
        this.state.onSaveSuccess();
      })
      .catch((error) => {
        let errors = [];
        Object.keys(error.response.data.errors).forEach(function (
          key,
          idx,
          arr
        ) {
          error.response.data.errors[key].forEach((elem) => {
            errors.push(elem);
          });
        });
        console.log(errors);
        this.setState({ ErrorMessage: errors });
      });
  };

  render() {
    return (
      <Form className="form-data" onSubmit={this.handleSubmit}>
        <Row>
          <Col style={{ color: "Red" }}>
            <ul>
              {this.state.ErrorMessage.map((msg) => (
                <li key={msg}>{msg}</li>
              ))}
            </ul>
          </Col>
        </Row>
        <input type="hidden" id="userId" value={this.state.userId} />
        <Row>
          <Col xs={4}>
            <FormControl
              controlId="formFirstName"
              name="firstName"
              label="First Name"
              placeholder="Enter First Name"
              onChange={this.onChange}
              value={this.state.firstName}
              readOnly={this.state.editable}
            ></FormControl>
          </Col>
          <Col xs={4}>
            <FormControl
              controlId="formLastName"
              name="lastName"
              label="Last Name"
              placeholder="Enter Last Name"
              onChange={this.onChange}
              value={this.state.lastName}
              readOnly={this.state.editable}
              ></FormControl>
          </Col>
        </Row>
        <Row>
          <Col xs={4}>
            <FormControl
              controlId="formEmail"
              name="email"
              label="Email"
              placeholder="Enter Email Address"
              onChange={this.onChange}
              value={this.state.email}
            ></FormControl>
          </Col>
          <Col xs={4}>
            <FormControl
              controlId="formPhone"
              name="phone"
              label="Phone Number"
              placeholder="Enter Phone Number"
              onChange={this.onChange}
              value={this.state.phone}
            ></FormControl>
          </Col>
        </Row>
        <Row>
          <label>
            <b>
              <u>Address :</u>
            </b>
          </label>
          <input type="hidden" id="addressId" value={this.state.addressId} />
        </Row>
        <Row>
          <Col xs={4}>
            <FormControl
              controlId="formDoorNo"
              label="Door #"
              name="doorNo"
              placeholder="Enter Door #"
              onChange={this.onChange}
              value={this.state.doorNo}
            ></FormControl>
          </Col>
          <Col xs={4}>
            <FormControl
              controlId="formStreetName"
              name="streetName"
              label="Street Name"
              placeholder="Enter Street Name"
              onChange={this.onChange}
              value={this.state.streetName}
            ></FormControl>
          </Col>
          <Col xs={4}>
            <FormControl
              controlId="formCity"
              name="city"
              label="City"
              placeholder="Enter City"
              onChange={this.onChange}
              value={this.state.city}
            ></FormControl>
          </Col>
        </Row>
        <Row>
          <Col xs={4}>
            <FormControl
              controlId="formState"
              name="state"
              label="State"
              placeholder="Enter State"
              onChange={this.onChange}
              value={this.state.state}
            ></FormControl>
          </Col>
          <Col xs={4}>
            <FormControl
              controlId="formCountry"
              name="country"
              label="Country"
              placeholder="Enter Country"
              onChange={this.onChange}
              value={this.state.country}
            ></FormControl>
          </Col>
          <Col xs={4}>
            <FormControl
              controlId="formZip"
              name="postCode"
              label="Zip Code"
              placeholder="Enter Zip"
              onChange={this.onChange}
              value={this.state.postCode}
            ></FormControl>
          </Col>
        </Row>
        <Row>
          <Col className="col-md-4">
            <Button
              as="a"
              variant="success"
              style={{ display: "block" }}
              onClick={this.handleSubmit}
              type="submit"
            >
              Save
            </Button>
          </Col>
          <Col className="col-md-4">
            <Button
              as="a"
              variant="warning"
              style={{ display: "block" }}
              onClick={this.state.onCancel}
              type="cancel"
            >
              Cancel
            </Button>
          </Col>
        </Row>
      </Form>
    );
  }
}

export default UserForm;
