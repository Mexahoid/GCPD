import React, { Component } from 'react';

export class FetchData extends Component {
    displayName = FetchData.name

    constructor(props) {
        super(props);
        this.state = { companies: [], loading: true };

        fetch('https://gcpd-294815.oa.r.appspot.com/LaborExchange/api/companytypes')
            .then(response => response.json())
            .then(data => {
                this.setState({ companies: data[1], loading: false });
            });
    }

    static renderCompaniesTable(companies) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                    </tr>
                </thead>
                <tbody>
                    {companies.map(company =>
                        <tr key={company.id}>
                            <td>{company.id}</td>
                            <td>{company.company}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderCompaniesTable(this.state.companies);

        return (
            <div>
                <h1>CompanyTypes</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
}
