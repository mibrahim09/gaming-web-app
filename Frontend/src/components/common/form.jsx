import React, { Component } from "react";
import Input from "./input";
class Form extends Component {
  state = {
    data: {},
    errors: {},
  };

  validate = () => {
    const { data } = this.state;

    const joiResult = this.schema.validate(data, {
      abortEarly: false,
    });
    if (!joiResult.error) {
      return null;
    } // empty errors
    const errors = this.state.errors;
    joiResult.error.details.forEach((element) => {
      errors[element.path] = element.message;
    });
    return errors;
  };

  validateProperty = (input) => {
    const { name, value } = input;

    const customSchema = this.schema.extract(name); // extract the schema i need.

    const joiResult = customSchema.validate(value);
    if (joiResult.error) return joiResult.error.message;
  };

  handleSubmit = (e) => {
    e.preventDefault(); // to prevent the submission of the form!

    const errors = this.validate();

    this.setState({ errors: errors || [] });
    if (errors) return;

    this.doSubmit();
  };

  handleChange = (e) => {
    const input = e.currentTarget;
    const error = this.validateProperty(input);
    const errors = [...this.state.errors];
    if (error) errors[input.name] = error;
    else delete errors[input.name];

    const data = { ...this.state.data }; // clone the old.
    data[input.name] = input.value; // get the currentInput and get the name to set its value.
    this.setState({ data: data, errors: errors });
  };

  renderBtn = (label) => {
    return (
      <button
        type="submit"
        disabled={this.validate()}
        className="btn btn-primary"
        onClick={this.handleSubmit}
      >
        {label}
      </button>
    );
  };
  renderInput = (name, label, type = "text") => {
    return (
      <Input
        label={label}
        type={type}
        value={this.state.data[name]}
        onChange={this.handleChange}
        error={this.state.errors[name]}
        name={name}
      ></Input>
    );
  };
}

export default Form;