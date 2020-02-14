import React, { Component } from 'react';
import { TweetData } from './TweetData';
import { ProfileData } from './ProfileData';
import './TwitterStyle.css';

export class Search extends Component {
    static displayName = Search.name;

    constructor(props) {
        super(props);
        this.state = { screenName: '', twitterdata: [], loading: true, };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({ screenName: event.target.value });
        console.log(this.screenName);
    }

    handleSubmit(event) {
        this.populateTwitterData();
        event.preventDefault();
    }


    renderDataTable(twitterdata) {
        if (twitterdata === "NoData") {
            return (
                <div className="divSoloOuter">
                    <p className="noData">No Content Found!</p>
                    <div className="divSoloSearch">
                        <form onSubmit={this.handleSubmit}>
                            <div className="divMenuOuter">
                                <div className="divMenuUpper">
                                    <div className="divMenuLeft">
                                        <label className="label">Twitter Screen Name</label>
                                    </div>
                                    <div className="divMenuRight">
                                        <input type="text" value={this.state.screenName} onChange={this.handleChange} />
                                    </div>
                                </div>
                                <div className="divMenuBottom">
                                    <input type="submit" value="Search" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            );
        }
        else {
            return (
                <div className="divOuter">
                    <div className="divRight">
                        <form onSubmit={this.handleSubmit}>
                            <div className="divMenuOuter">
                                <div className="divMenuUpper">
                                    <div className="divMenuLeft">
                                        <label className="label">Twitter Screen Name</label>
                                    </div>
                                    <div className="divMenuRight">
                                        <input type="text" value={this.state.screenName} onChange={this.handleChange} />
                                    </div>
                                </div>
                                <div className="divMenuBottom">
                                    <input type="submit" value="Search" />
                                </div>
                            </div>
                        </form>
                    </div>
                    <div className="divLeft">
                        <div>
                            <ProfileData pdata={twitterdata.profileInfo} />
                        </div>
                    </div>
                    <div className="divMiddle">
                        <TweetData datatweet={twitterdata.tweets} />
                    </div>
                </div>
            );
        }
    }

    renderDataTableInitial() {
        return (
            <div className="divSoloOuter">
                <div className="divSoloSearch">
                    <form onSubmit={this.handleSubmit}>
                        <div className="divMenuOuter">
                            <div className="divMenuUpper">
                                <div className="divMenuLeft">
                                    <label className="label">Twitter Screen Name</label>
                                </div>
                                <div className="divMenuRight">
                                    <input type="text" value={this.state.screenName} onChange={this.handleChange} />
                                </div>
                            </div>
                            <div className="divMenuBottom">
                                <input type="submit" value="Search" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        );

    }


    render() {

        let contents = this.state.loading
            ? this.renderDataTableInitial()
            : this.renderDataTable(this.state.twitterdata);

        return (
            <div>
                {contents}
            </div>
        );

    }

    async populateTwitterData() {

        try {
            console.log("Inside Populate data");
            const response = await fetch('home' + '?screenName=$' + this.state.screenName, {
                method: 'GET',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            });
            let data = [];
            if (response.statusText == "OK") {
                data = await response.json();
                console.log(data);
            }
            else {
                data = "NoData"
            }
            this.setState({ twitterdata: data, loading: false });
        }
        catch (e) {
            console.log('EXCEPTION THROWN: ' + e);
        }
    }
}
