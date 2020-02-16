import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <p>React Sample single-page application, built with:</p>
            <p>Asp.net Core Web Server side is built using C#, dotnet core 3.1, Asp.net Core and EF Core </p>
            <p>Web server also using EF core In Memory SQL Provider which can be used without actually installing any SQL Server</p>
            <p>React Application based on react appplication with Asp.net Core Web Server based on Entity Framework Core MVP for showing integrating data from the server.</p>
      </div>
    );
  }
}
