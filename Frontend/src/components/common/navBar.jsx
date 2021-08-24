import React from 'react'
import { Link, BrowserRouter } from 'react-router-dom'
import { Navbar, Container, Nav, NavDropdown } from 'react-bootstrap'

import { CustomNavLink, CustomNavDropDownLink } from './customNavLink'

const MyNavBar = (props) => {
  const user = props.user
  return (
    <Navbar bg="light" expand="lg">
      <Container>
        <Navbar.Brand href="#">Nova4Gaming</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <CustomNavLink to="/">Home</CustomNavLink>
            <CustomNavLink to="/user/register">Register</CustomNavLink>
            <CustomNavLink to="/downloads">Downloads</CustomNavLink>
            <CustomNavLink to="/ranks">Ranks</CustomNavLink>
            {!user && (
              <NavDropdown title="User" id="basic-nav-dropdown">
                <CustomNavDropDownLink to="/user/login">
                  Login
                </CustomNavDropDownLink>
                <CustomNavDropDownLink to="/user/forgotpassword">
                  Forgot Password
                </CustomNavDropDownLink>
              </NavDropdown>
            )}
            {user && (
              <NavDropdown title={user.Username} id="basic-nav-dropdown">
                <CustomNavDropDownLink to="/user/profile">
                  Profile
                </CustomNavDropDownLink>
                <CustomNavDropDownLink to="/user/changepass">
                  Change Password
                </CustomNavDropDownLink>
                <CustomNavDropDownLink to="/user/logout">
                  Logout
                </CustomNavDropDownLink>
              </NavDropdown>
            )}
            <CustomNavLink to="/team">Team</CustomNavLink>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  )
}

export default MyNavBar
