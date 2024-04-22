import React, { Component } from 'react';
import { Button, Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
    }
    goto() {
        window.location = "https://localhost:44324/Movies";
    }

  render () {
    return (
      <header>
        <Navbar color="dark" className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3">
          <Container>
            <NavbarBrand tag={Link} to="/home">MOTC</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-light" to="/">Home</NavLink>
                </NavItem>
                <NavItem>
                   <NavLink className="text-dark"><Button color="primary"  onClick={this.goto}> Admin View</Button></NavLink>
                </NavItem>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
