import React, { Component } from 'react';
import './TwitterStyle.css';

export class ProfileData extends Component {
    render() {
        if (this.props.pdata === undefined) {
            return (
                <div></div>
            );
        }
        else {
            return (
                <div>
                    <div className="divProfilePicture">
                        <img className="imageProfile" alt='Profile' src={this.props.pdata.profileImageUrl}></img>
                    </div>
                    <div className="divProfileName">
                        <h2>{this.props.pdata.userName} ({this.props.pdata.screenName})</h2>
                    </div>
                    <div className="divProfileInfo">
                        <p className="profileInfoDesc">{this.props.pdata.description}</p>
                    </div>
                    <div className="divProfileInfo">
                        <p className="profileInfo">Followers: {this.props.pdata.followers}</p>
                        <p className="profileInfo">Following: {this.props.pdata.following}</p>
                    </div>
                </div>
            );
        }
    }
}