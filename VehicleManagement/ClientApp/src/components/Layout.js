import React, { Component } from 'react';
import { Container } from 'reactstrap';

export class Layout extends Component {
  static displayName = Layout.name;

    render() {
        return (
            <div style={{ "margin-top": "70px"}}>
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
