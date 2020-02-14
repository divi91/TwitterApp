import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './Layout';
import { Search } from './Search';
import { About } from './About';
import './custom.css'


export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Search} />
                <Route path='/about' component={About} />
            </Layout>
        );
    }
}
