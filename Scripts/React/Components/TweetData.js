import React, { Component } from 'react';
import './TwitterStyle.css';

export class TweetData extends Component {
    render() {
        if (this.props.datatweet === undefined) {
            return (
                <div></div>
            );
        }
        else {
            return (
                <div className='divTable'>
                    <table className='tableData' align='center'>
                        <tbody>
                            {this.props.datatweet.map(dtweet =>
                                <div>
                                    <tr>
                                        <td className='columnExtra'>{dtweet.created}</td>
                                        <td className='columnExtra'>Retweets: {dtweet.retweets}</td>
                                    </tr>
                                    <tr><td className='columnTweet' colSpan='3'>{dtweet.tweettext}</td></tr>
                                    {dtweet.mediaType == ''
                                        ? ''
                                        : dtweet.mediaType == 'video'
                                            ? <tr><td><video className='videoMedia' controls >
                                                <source src={dtweet.mediaUrl} type='video/mp4' />
                                            </video></td></tr>
                                            : <tr><td><img className='imageMedia' alt='media' src={dtweet.mediaUrl}></img></td></tr>
                                    }
                                    <tr><td className='blank_row' colSpan='3'></td></tr>
                                </div>
                            )}
                        </tbody>
                    </table>
                </div>
            );
        }
    }
}