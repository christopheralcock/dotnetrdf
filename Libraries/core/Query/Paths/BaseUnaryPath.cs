﻿/*

Copyright Robert Vesse 2009-10
rvesse@vdesign-studios.com

------------------------------------------------------------------------

This file is part of dotNetRDF.

dotNetRDF is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

dotNetRDF is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with dotNetRDF.  If not, see <http://www.gnu.org/licenses/>.

------------------------------------------------------------------------

dotNetRDF may alternatively be used under the LGPL or MIT License

http://www.gnu.org/licenses/lgpl.html
http://www.opensource.org/licenses/mit-license.php

If these licenses are not suitable for your intended use please contact
us at the above stated email address to discuss alternative
terms.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VDS.RDF.Query.Algebra;

namespace VDS.RDF.Query.Paths
{
    /// <summary>
    /// Abstract Base Class for Unary Path operators
    /// </summary>
    public abstract class BaseUnaryPath : ISparqlPath
    {
        /// <summary>
        /// Path
        /// </summary>
        protected ISparqlPath _path;

        /// <summary>
        /// Creates a new Unary Path
        /// </summary>
        /// <param name="path">Path</param>
        public BaseUnaryPath(ISparqlPath path)
        {
            this._path = path;
        }

        /// <summary>
        /// Gets whether the path is simple
        /// </summary>
        public abstract bool IsSimple
        {
            get;
        }


        /// <summary>
        /// Gets whether the Path permits zero-length paths
        /// </summary>
        public virtual bool AllowsZeroLength
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the Inner Path
        /// </summary>
        public ISparqlPath Path
        {
            get
            {
                return this._path;
            }
        }

        /// <summary>
        /// Evaluates the Path using the given Path Evaluation Context
        /// </summary>
        /// <param name="context">Path Evaluation Context</param>
        public abstract void Evaluate(PathEvaluationContext context);

        /// <summary>
        /// Generates the Algebra Transform of the Path
        /// </summary>
        /// <param name="context">Transform Context</param>
        /// <returns></returns>
        public abstract void ToAlgebra(PathTransformContext context);

        public abstract ISparqlAlgebra ToAlgebraOperator(PathTransformContext context);
    }
}
