import React, { Component } from 'react'

const Input = ({ name, label, error, ...rest }) => {
  return (
    <div className="mb-3">
      <label htmlFor={name} className="form-label mb-3">
        {label}
      </label>
      <input
        id={name}
        name={name}
        placeholder={label}
        {...rest}
        className="form-control"
      />
      {
        // {...rest} extracts the types without adding them manually.
      }
      {error && <div className="alert alert-danger">{error}</div>}
    </div>
  )
}
export default Input
