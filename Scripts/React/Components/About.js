import React, { Component } from 'react';
import './TwitterStyle.css';

export class About extends Component {
    static displayName = About.name;

    render() {
        return (
            <div className="divAbout">
                <p>An application built using React to fetch Twitter Feeds of given Screen Name.</p>
            </div>
        );
    }
}
