﻿// <copyright file="Matrix.Arithmetic.cs" company="Math.NET">
// Math.NET Numerics, part of the Math.NET Project
// http://numerics.mathdotnet.com
// http://github.com/mathnet/mathnet-numerics
// http://mathnetnumerics.codeplex.com
//
// Copyright (c) 2009-2013 Math.NET
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// </copyright>

using System;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.Properties;

namespace MathNet.Numerics.LinearAlgebra
{
    /// <summary>
    /// Defines the base class for <c>Matrix</c> classes.
    /// </summary>
    public abstract partial class Matrix<T>
    {
        /// <summary>
        /// The value of 1.0.
        /// </summary>
        public static readonly T One = Builder<T>.Instance.One;

        /// <summary>
        /// The value of 0.0.
        /// </summary>
        public static readonly T Zero = Builder<T>.Instance.Zero;

        /// <summary>
        /// Negate each element of this matrix and place the results into the result matrix.
        /// </summary>
        /// <param name="result">The result of the negation.</param>
        protected abstract void DoNegate(Matrix<T> result);

        /// <summary>
        /// Complex conjugates each element of this matrix and place the results into the result matrix.
        /// </summary>
        /// <param name="result">The result of the conjugation.</param>
        protected abstract void DoConjugate(Matrix<T> result);

        /// <summary>
        /// Add a scalar to each element of the matrix and stores the result in the result vector.
        /// </summary>
        /// <param name="scalar">The scalar to add.</param>
        /// <param name="result">The matrix to store the result of the addition.</param>
        protected abstract void DoAdd(T scalar, Matrix<T> result);

        /// <summary>
        /// Adds another matrix to this matrix.
        /// </summary>
        /// <param name="other">The matrix to add to this matrix.</param>
        /// <param name="result">The matrix to store the result of the addition.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the two matrices don't have the same dimensions.</exception>
        protected abstract void DoAdd(Matrix<T> other, Matrix<T> result);

        /// <summary>
        /// Subtracts a scalar from each element of the matrix and stores the result in the result matrix.
        /// </summary>
        /// <param name="scalar">The scalar to subtract.</param>
        /// <param name="result">The matrix to store the result of the subtraction.</param>
        protected abstract void DoSubtract(T scalar, Matrix<T> result);

        /// <summary>
        /// Subtracts each element of the matrix from a scalar and stores the result in the result matrix.
        /// </summary>
        /// <param name="scalar">The scalar to subtract from.</param>
        /// <param name="result">The matrix to store the result of the subtraction.</param>
        protected virtual void DoSubtractFrom(T scalar, Matrix<T> result)
        {
            DoNegate(result);
            result.DoAdd(scalar, result);
        }

        /// <summary>
        /// Subtracts another matrix from this matrix.
        /// </summary>
        /// <param name="other">The matrix to subtract.</param>
        /// <param name="result">The matrix to store the result of the subtraction.</param>
        protected abstract void DoSubtract(Matrix<T> other, Matrix<T> result);

        /// <summary>
        /// Multiplies each element of the matrix by a scalar and places results into the result matrix.
        /// </summary>
        /// <param name="scalar">The scalar to multiply the matrix with.</param>
        /// <param name="result">The matrix to store the result of the multiplication.</param>
        protected abstract void DoMultiply(T scalar, Matrix<T> result);

        /// <summary>
        /// Multiplies this matrix with a vector and places the results into the result vector.
        /// </summary>
        /// <param name="rightSide">The vector to multiply with.</param>
        /// <param name="result">The result of the multiplication.</param>
        protected abstract void DoMultiply(Vector<T> rightSide, Vector<T> result);

        /// <summary>
        /// Multiplies this matrix with another matrix and places the results into the result matrix.
        /// </summary>
        /// <param name="other">The matrix to multiply with.</param>
        /// <param name="result">The result of the multiplication.</param>
        protected abstract void DoMultiply(Matrix<T> other, Matrix<T> result);

        /// <summary>
        /// Multiplies this matrix with transpose of another matrix and places the results into the result matrix.
        /// </summary>
        /// <param name="other">The matrix to multiply with.</param>
        /// <param name="result">The result of the multiplication.</param>
        protected abstract void DoTransposeAndMultiply(Matrix<T> other, Matrix<T> result);

        /// <summary>
        /// Multiplies the transpose of this matrix with a vector and places the results into the result vector.
        /// </summary>
        /// <param name="rightSide">The vector to multiply with.</param>
        /// <param name="result">The result of the multiplication.</param>
        protected abstract void DoTransposeThisAndMultiply(Vector<T> rightSide, Vector<T> result);

        /// <summary>
        /// Multiplies the transpose of this matrix with another matrix and places the results into the result matrix.
        /// </summary>
        /// <param name="other">The matrix to multiply with.</param>
        /// <param name="result">The result of the multiplication.</param>
        protected abstract void DoTransposeThisAndMultiply(Matrix<T> other, Matrix<T> result);

        /// <summary>
        /// Divides each element of the matrix by a scalar and places results into the result matrix.
        /// </summary>
        /// <param name="divisor">The scalar denominator to use.</param>
        /// <param name="result">The matrix to store the result of the division.</param>
        protected abstract void DoDivide(T divisor, Matrix<T> result);

        /// <summary>
        /// Divides a scalar by each element of the matrix and stores the result in the result matrix.
        /// </summary>
        /// <param name="dividend">The scalar numerator to use.</param>
        /// <param name="result">The matrix to store the result of the division.</param>
        protected abstract void DoDivideByThis(T dividend, Matrix<T> result);

        /// <summary>
        /// Computes the modulus for the given divisor each element of the matrix.
        /// </summary>
        /// <param name="divisor">The scalar denominator to use.</param>
        /// <param name="result">Matrix to store the results in.</param>
        protected abstract void DoModulus(T divisor, Matrix<T> result);

        /// <summary>
        /// Computes the modulus for the given dividend for each element of the matrix.
        /// </summary>
        /// <param name="dividend">The scalar numerator to use.</param>
        /// <param name="result">A vector to store the results in.</param>
        protected abstract void DoModulusByThis(T dividend, Matrix<T> result);

        /// <summary>
        /// Pointwise multiplies this matrix with another matrix and stores the result into the result matrix.
        /// </summary>
        /// <param name="other">The matrix to pointwise multiply with this one.</param>
        /// <param name="result">The matrix to store the result of the pointwise multiplication.</param>
        protected abstract void DoPointwiseMultiply(Matrix<T> other, Matrix<T> result);

        /// <summary>
        /// Pointwise divide this matrix by another matrix and stores the result into the result matrix.
        /// </summary>
        /// <param name="divisor">The pointwise denominator matrix to use.</param>
        /// <param name="result">The matrix to store the result of the pointwise division.</param>
        protected abstract void DoPointwiseDivide(Matrix<T> divisor, Matrix<T> result);

        /// <summary>
        /// Pointwise modulus this matrix with another matrix and stores the result into the result matrix.
        /// </summary>
        /// <param name="divisor">The pointwise denominator matrix to use</param>
        /// <param name="result">The result of the modulus.</param>
        protected abstract void DoPointwiseModulus(Matrix<T> divisor, Matrix<T> result);

        /// <summary>
        /// Adds a scalar to each element of the matrix.
        /// </summary>
        /// <param name="scalar">The scalar to add.</param>
        /// <returns>The result of the addition.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the two matrices don't have the same dimensions.</exception>
        public Matrix<T> Add(T scalar)
        {
            if (scalar.Equals(Zero))
            {
                return Clone();
            }

            var result = CreateMatrix(RowCount, ColumnCount);
            DoAdd(scalar, result);
            return result;
        }

        /// <summary>
        /// Adds a scalar to each element of the matrix and stores the result in the result matrix.
        /// </summary>
        /// <param name="scalar">The scalar to add.</param>
        /// <param name="result">The matrix to store the result of the addition.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the two matrices don't have the same dimensions.</exception>
        public void Add(T scalar, Matrix<T> result)
        {
            if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
            {
                throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, result, "result");
            }

            if (scalar.Equals(Zero))
            {
                CopyTo(result);
                return;
            }

            DoAdd(scalar, result);
        }

        /// <summary>
        /// Adds another matrix to this matrix.
        /// </summary>
        /// <param name="other">The matrix to add to this matrix.</param>
        /// <returns>The result of the addition.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the two matrices don't have the same dimensions.</exception>
        public virtual Matrix<T> Add(Matrix<T> other)
        {
            if (other.RowCount != RowCount || other.ColumnCount != ColumnCount)
            {
                throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, other);
            }

            var result = CreateMatrix(RowCount, ColumnCount);
            DoAdd(other, result);
            return result;
        }

        /// <summary>
        /// Adds another matrix to this matrix.
        /// </summary>
        /// <param name="other">The matrix to add to this matrix.</param>
        /// <param name="result">The matrix to store the result of the addition.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the two matrices don't have the same dimensions.</exception>
        public void Add(Matrix<T> other, Matrix<T> result)
        {
            if (other.RowCount != RowCount || other.ColumnCount != ColumnCount)
            {
                throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, other, "other");
            }

            if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
            {
                throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, result, "result");
            }

            DoAdd(other, result);
        }

        /// <summary>
        /// Subtracts a scalar from each element of the matrix.
        /// </summary>
        /// <param name="scalar">The scalar to subtract.</param>
        /// <returns>A new matrix containing the subtraction of this matrix and the scalar.</returns>
        public Matrix<T> Subtract(T scalar)
        {
            if (scalar.Equals(Zero))
            {
                return Clone();
            }

            var result = CreateMatrix(RowCount, ColumnCount);
            DoSubtract(scalar, result);
            return result;
        }

        /// <summary>
        /// Subtracts a scalar from each element of the matrix and stores the result in the result matrix.
        /// </summary>
        /// <param name="scalar">The scalar to subtract.</param>
        /// <param name="result">The matrix to store the result of the subtraction.</param>
        /// <exception cref="ArgumentException">If this matrix and <paramref name="result"/> are not the same size.</exception>
        public void Subtract(T scalar, Matrix<T> result)
        {
            if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
            {
                throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, result, "result");
            }

            if (scalar.Equals(Zero))
            {
                CopyTo(result);
                return;
            }

            DoSubtract(scalar, result);
        }

        /// <summary>
        /// Subtracts each element of the matrix from a scalar.
        /// </summary>
        /// <param name="scalar">The scalar to subtract from.</param>
        /// <returns>A new matrix containing the subtraction of the scalar and this matrix.</returns>
        public Matrix<T> SubtractFrom(T scalar)
        {
            var result = CreateMatrix(RowCount, ColumnCount);
            DoSubtractFrom(scalar, result);
            return result;
        }

        /// <summary>
        /// Subtracts each element of the matrix from a scalar and stores the result in the result matrix.
        /// </summary>
        /// <param name="scalar">The scalar to subtract from.</param>
        /// <param name="result">The matrix to store the result of the subtraction.</param>
        /// <exception cref="ArgumentException">If this matrix and <paramref name="result"/> are not the same size.</exception>
        public void SubtractFrom(T scalar, Matrix<T> result)
        {
            if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
            {
                throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, result, "result");
            }

            DoSubtractFrom(scalar, result);
        }

        /// <summary>
        /// Subtracts another matrix from this matrix.
        /// </summary>
        /// <param name="other">The matrix to subtract.</param>
        /// <returns>The result of the subtraction.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the two matrices don't have the same dimensions.</exception>
        public virtual Matrix<T> Subtract(Matrix<T> other)
        {
            if (other.RowCount != RowCount || other.ColumnCount != ColumnCount)
            {
                throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, other);
            }

            var result = CreateMatrix(RowCount, ColumnCount);
            DoSubtract(other, result);
            return result;
        }

        /// <summary>
        /// Subtracts another matrix from this matrix.
        /// </summary>
        /// <param name="other">The matrix to subtract.</param>
        /// <param name="result">The matrix to store the result of the subtraction.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the two matrices don't have the same dimensions.</exception>
        public void Subtract(Matrix<T> other, Matrix<T> result)
        {
            if (other.RowCount != RowCount || other.ColumnCount != ColumnCount)
            {
                throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, other, "other");
            }

            if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
            {
                throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, result, "result");
            }

            DoSubtract(other, result);
        }

        /// <summary>
        /// Multiplies each element of this matrix with a scalar.
        /// </summary>
        /// <param name="scalar">The scalar to multiply with.</param>
        /// <returns>The result of the multiplication.</returns>
        public Matrix<T> Multiply(T scalar)
        {
            if (scalar.Equals(One))
            {
                return Clone();
            }

            if (scalar.Equals(Zero))
            {
                return CreateMatrix(RowCount, ColumnCount);
            }

            var result = CreateMatrix(RowCount, ColumnCount);
            DoMultiply(scalar, result);
            return result;
        }

        /// <summary>
        /// Multiplies each element of the matrix by a scalar and places results into the result matrix.
        /// </summary>
        /// <param name="scalar">The scalar to multiply the matrix with.</param>
        /// <param name="result">The matrix to store the result of the multiplication.</param>
        /// <exception cref="ArgumentException">If the result matrix's dimensions are not the same as this matrix.</exception>
        public void Multiply(T scalar, Matrix<T> result)
        {
            if (result.RowCount != RowCount)
            {
                throw new ArgumentException(Resources.ArgumentMatrixSameRowDimension, "result");
            }

            if (result.ColumnCount != ColumnCount)
            {
                throw new ArgumentException(Resources.ArgumentMatrixSameColumnDimension, "result");
            }

            if (scalar.Equals(One))
            {
                CopyTo(result);
                return;
            }

            if (scalar.Equals(Zero))
            {
                result.Clear();
                return;
            }

            DoMultiply(scalar, result);
        }

        /// <summary>
        /// Divides each element of this matrix with a scalar.
        /// </summary>
        /// <param name="scalar">The scalar to divide with.</param>
        /// <returns>The result of the division.</returns>
        public Matrix<T> Divide(T scalar)
        {
            if (scalar.Equals(One))
            {
                return Clone();
            }

            if (scalar.Equals(Zero))
            {
                throw new DivideByZeroException();
            }

            var result = CreateMatrix(RowCount, ColumnCount);
            DoDivide(scalar, result);
            return result;
        }

        /// <summary>
        /// Divides each element of the matrix by a scalar and places results into the result matrix.
        /// </summary>
        /// <param name="scalar">The scalar to divide the matrix with.</param>
        /// <param name="result">The matrix to store the result of the division.</param>
        /// <exception cref="ArgumentException">If the result matrix's dimensions are not the same as this matrix.</exception>
        public void Divide(T scalar, Matrix<T> result)
        {
            if (result.RowCount != RowCount)
            {
                throw new ArgumentException(Resources.ArgumentMatrixSameRowDimension, "result");
            }

            if (result.ColumnCount != ColumnCount)
            {
                throw new ArgumentException(Resources.ArgumentMatrixSameColumnDimension, "result");
            }

            if (scalar.Equals(One))
            {
                CopyTo(result);
                return;
            }

            if (scalar.Equals(Zero))
            {
                throw new DivideByZeroException();
            }

            DoDivide(scalar, result);
        }

        /// <summary>
        /// Divides a scalar by each element of the matrix.
        /// </summary>
        /// <param name="scalar">The scalar to divide.</param>
        /// <returns>The result of the division.</returns>
        public Matrix<T> DivideByThis(T scalar)
        {
            var result = CreateMatrix(RowCount, ColumnCount);
            DoDivideByThis(scalar, result);
            return result;
        }

        /// <summary>
        /// Divides a scalar by each element of the matrix and places results into the result matrix.
        /// </summary>
        /// <param name="scalar">The scalar to divide.</param>
        /// <param name="result">The matrix to store the result of the division.</param>
        /// <exception cref="ArgumentException">If the result matrix's dimensions are not the same as this matrix.</exception>
        public void DivideByThis(T scalar, Matrix<T> result)
        {
            if (result.RowCount != RowCount)
            {
                throw new ArgumentException(Resources.ArgumentMatrixSameRowDimension, "result");
            }

            if (result.ColumnCount != ColumnCount)
            {
                throw new ArgumentException(Resources.ArgumentMatrixSameColumnDimension, "result");
            }

            DoDivideByThis(scalar, result);
        }

        /// <summary>
        /// Multiplies this matrix by a vector and returns the result.
        /// </summary>
        /// <param name="rightSide">The vector to multiply with.</param>
        /// <returns>The result of the multiplication.</returns>
        /// <exception cref="ArgumentException">If <c>this.ColumnCount != rightSide.Count</c>.</exception>
        public Vector<T> Multiply(Vector<T> rightSide)
        {
            if (ColumnCount != rightSide.Count)
            {
                throw DimensionsDontMatch<ArgumentException>(this, rightSide, "rightSide");
            }

            var ret = CreateVector(RowCount);
            DoMultiply(rightSide, ret);
            return ret;
        }

        /// <summary>
        /// Multiplies this matrix with a vector and places the results into the result vector.
        /// </summary>
        /// <param name="rightSide">The vector to multiply with.</param>
        /// <param name="result">The result of the multiplication.</param>
        /// <exception cref="ArgumentException">If <strong>result.Count != this.RowCount</strong>.</exception>
        /// <exception cref="ArgumentException">If <strong>this.ColumnCount != <paramref name="rightSide"/>.Count</strong>.</exception>
        public virtual void Multiply(Vector<T> rightSide, Vector<T> result)
        {
            if (ColumnCount != rightSide.Count)
            {
                throw DimensionsDontMatch<ArgumentException>(this, rightSide, "rightSide");
            }

            if (RowCount != result.Count)
            {
                throw DimensionsDontMatch<ArgumentException>(this, result, "result");
            }

            if (ReferenceEquals(rightSide, result))
            {
                var tmp = result.CreateVector(result.Count);
                DoMultiply(rightSide, tmp);
                tmp.CopyTo(result);
            }
            else
            {
                DoMultiply(rightSide, result);
            }
        }

        /// <summary>
        /// Left multiply a matrix with a vector ( = vector * matrix ).
        /// </summary>
        /// <param name="leftSide">The vector to multiply with.</param>
        /// <returns>The result of the multiplication.</returns>
        /// <exception cref="ArgumentException">If <strong>this.RowCount != <paramref name="leftSide"/>.Count</strong>.</exception>
        public Vector<T> LeftMultiply(Vector<T> leftSide)
        {
            if (RowCount != leftSide.Count)
            {
                throw DimensionsDontMatch<ArgumentException>(this, leftSide, "leftSide");
            }

            var ret = CreateVector(ColumnCount);
            DoLeftMultiply(leftSide, ret);
            return ret;
        }

        /// <summary>
        /// Left multiply a matrix with a vector ( = vector * matrix ) and place the result in the result vector.
        /// </summary>
        /// <param name="leftSide">The vector to multiply with.</param>
        /// <param name="result">The result of the multiplication.</param>
        /// <exception cref="ArgumentException">If <strong>result.Count != this.ColumnCount</strong>.</exception>
        /// <exception cref="ArgumentException">If <strong>this.RowCount != <paramref name="leftSide"/>.Count</strong>.</exception>
        public virtual void LeftMultiply(Vector<T> leftSide, Vector<T> result)
        {
            if (RowCount != leftSide.Count)
            {
                throw DimensionsDontMatch<ArgumentException>(this, leftSide, "leftSide");
            }

            if (ColumnCount != result.Count)
            {
                throw DimensionsDontMatch<ArgumentException>(this, result, "result");
            }

            if (ReferenceEquals(leftSide, result))
            {
                var tmp = result.CreateVector(result.Count);
                DoLeftMultiply(leftSide, tmp);
                tmp.CopyTo(result);
            }
            else
            {
                DoLeftMultiply(leftSide, result);
            }
        }

        /// <summary>
        /// Left multiply a matrix with a vector ( = vector * matrix ) and place the result in the result vector.
        /// </summary>
        /// <param name="leftSide">The vector to multiply with.</param>
        /// <param name="result">The result of the multiplication.</param>
        protected void DoLeftMultiply(Vector<T> leftSide, Vector<T> result)
        {
            DoTransposeThisAndMultiply(leftSide, result);
        }

        /// <summary>
        /// Multiplies this matrix with another matrix and places the results into the result matrix.
        /// </summary>
        /// <param name="other">The matrix to multiply with.</param>
        /// <param name="result">The result of the multiplication.</param>
        /// <exception cref="ArgumentException">If <strong>this.Columns != other.Rows</strong>.</exception>
        /// <exception cref="ArgumentException">If the result matrix's dimensions are not the this.Rows x other.Columns.</exception>
        public virtual void Multiply(Matrix<T> other, Matrix<T> result)
        {
            if (ColumnCount != other.RowCount || result.RowCount != RowCount || result.ColumnCount != other.ColumnCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, other, result);
            }

            if (ReferenceEquals(this, result) || ReferenceEquals(other, result))
            {
                var tmp = result.CreateMatrix(result.RowCount, result.ColumnCount);
                DoMultiply(other, tmp);
                tmp.CopyTo(result);
            }
            else
            {
                DoMultiply(other, result);
            }
        }

        /// <summary>
        /// Multiplies this matrix with another matrix and returns the result.
        /// </summary>
        /// <param name="other">The matrix to multiply with.</param>
        /// <exception cref="ArgumentException">If <strong>this.Columns != other.Rows</strong>.</exception>
        /// <returns>The result of the multiplication.</returns>
        public virtual Matrix<T> Multiply(Matrix<T> other)
        {
            if (ColumnCount != other.RowCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, other);
            }

            var result = CreateMatrix(RowCount, other.ColumnCount);
            DoMultiply(other, result);
            return result;
        }

        /// <summary>
        /// Multiplies this matrix with transpose of another matrix and places the results into the result matrix.
        /// </summary>
        /// <param name="other">The matrix to multiply with.</param>
        /// <param name="result">The result of the multiplication.</param>
        /// <exception cref="ArgumentException">If <strong>this.Columns != other.ColumnCount</strong>.</exception>
        /// <exception cref="ArgumentException">If the result matrix's dimensions are not the this.RowCount x other.RowCount.</exception>
        public virtual void TransposeAndMultiply(Matrix<T> other, Matrix<T> result)
        {
            if (ColumnCount != other.ColumnCount || result.RowCount != RowCount || result.ColumnCount != other.RowCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, other, result);
            }

            if (ReferenceEquals(this, result) || ReferenceEquals(other, result))
            {
                var tmp = result.CreateMatrix(result.RowCount, result.ColumnCount);
                DoTransposeAndMultiply(other, tmp);
                tmp.CopyTo(result);
            }
            else
            {
                DoTransposeAndMultiply(other, result);
            }
        }

        /// <summary>
        /// Multiplies this matrix with transpose of another matrix and returns the result.
        /// </summary>
        /// <param name="other">The matrix to multiply with.</param>
        /// <exception cref="ArgumentException">If <strong>this.Columns != other.ColumnCount</strong>.</exception>
        /// <returns>The result of the multiplication.</returns>
        public virtual Matrix<T> TransposeAndMultiply(Matrix<T> other)
        {
            if (ColumnCount != other.ColumnCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, other);
            }

            var result = CreateMatrix(RowCount, other.RowCount);
            DoTransposeAndMultiply(other, result);
            return result;
        }

        /// <summary>
        /// Multiplies the transpose of this matrix by a vector and returns the result.
        /// </summary>
        /// <param name="rightSide">The vector to multiply with.</param>
        /// <returns>The result of the multiplication.</returns>
        /// <exception cref="ArgumentException">If <c>this.RowCount != rightSide.Count</c>.</exception>
        public Vector<T> TransposeThisAndMultiply(Vector<T> rightSide)
        {
            if (RowCount != rightSide.Count)
            {
                throw DimensionsDontMatch<ArgumentException>(this, rightSide, "rightSide");
            }

            var ret = CreateVector(ColumnCount);
            DoTransposeThisAndMultiply(rightSide, ret);
            return ret;
        }

        /// <summary>
        /// Multiplies the transpose of this matrix with a vector and places the results into the result vector.
        /// </summary>
        /// <param name="rightSide">The vector to multiply with.</param>
        /// <param name="result">The result of the multiplication.</param>
        /// <exception cref="ArgumentException">If <strong>result.Count != this.ColumnCount</strong>.</exception>
        /// <exception cref="ArgumentException">If <strong>this.RowCount != <paramref name="rightSide"/>.Count</strong>.</exception>
        public void TransposeThisAndMultiply(Vector<T> rightSide, Vector<T> result)
        {
            if (RowCount != rightSide.Count)
            {
                throw DimensionsDontMatch<ArgumentException>(this, rightSide, "rightSide");
            }

            if (ColumnCount != result.Count)
            {
                throw DimensionsDontMatch<ArgumentException>(this, result, "result");
            }

            if (ReferenceEquals(rightSide, result))
            {
                var tmp = result.CreateVector(result.Count);
                DoTransposeThisAndMultiply(rightSide, tmp);
                tmp.CopyTo(result);
            }
            else
            {
                DoTransposeThisAndMultiply(rightSide, result);
            }
        }

        /// <summary>
        /// Multiplies the transpose of this matrix with another matrix and places the results into the result matrix.
        /// </summary>
        /// <param name="other">The matrix to multiply with.</param>
        /// <param name="result">The result of the multiplication.</param>
        /// <exception cref="ArgumentException">If <strong>this.Rows != other.RowCount</strong>.</exception>
        /// <exception cref="ArgumentException">If the result matrix's dimensions are not the this.ColumnCount x other.ColumnCount.</exception>
        public void TransposeThisAndMultiply(Matrix<T> other, Matrix<T> result)
        {
            if (RowCount != other.RowCount || result.RowCount != ColumnCount || result.ColumnCount != other.ColumnCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, other, result);
            }

            if (ReferenceEquals(this, result) || ReferenceEquals(other, result))
            {
                var tmp = result.CreateMatrix(result.RowCount, result.ColumnCount);
                DoTransposeThisAndMultiply(other, tmp);
                tmp.CopyTo(result);
            }
            else
            {
                DoTransposeThisAndMultiply(other, result);
            }
        }

        /// <summary>
        /// Multiplies the transpose of this matrix with another matrix and returns the result.
        /// </summary>
        /// <param name="other">The matrix to multiply with.</param>
        /// <exception cref="ArgumentException">If <strong>this.Rows != other.RowCount</strong>.</exception>
        /// <returns>The result of the multiplication.</returns>
        public Matrix<T> TransposeThisAndMultiply(Matrix<T> other)
        {
            if (RowCount != other.RowCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, other);
            }

            var result = CreateMatrix(ColumnCount, other.ColumnCount);
            DoTransposeThisAndMultiply(other, result);
            return result;
        }

        /// <summary>
        /// Negate each element of this matrix.
        /// </summary>
        /// <returns>A matrix containing the negated values.</returns>
        public Matrix<T> Negate()
        {
            var result = CreateMatrix(RowCount, ColumnCount);
            DoNegate(result);
            return result;
        }

        /// <summary>
        /// Negate each element of this matrix and place the results into the result matrix.
        /// </summary>
        /// <param name="result">The result of the negation.</param>
        /// <exception cref="ArgumentException">if the result matrix's dimensions are not the same as this matrix.</exception>
        public void Negate(Matrix<T> result)
        {
            if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, result);
            }

            DoNegate(result);
        }

        /// <summary>
        /// Complex conjugate each element of this matrix.
        /// </summary>
        /// <returns>A matrix containing the conjugated values.</returns>
        public Matrix<T> Conjugate()
        {
            var result = CreateMatrix(RowCount, ColumnCount);
            DoConjugate(result);
            return result;
        }

        /// <summary>
        /// Complex conjugate each element of this matrix and place the results into the result matrix.
        /// </summary>
        /// <param name="result">The result of the conjugation.</param>
        /// <exception cref="ArgumentException">if the result matrix's dimensions are not the same as this matrix.</exception>
        public void Conjugate(Matrix<T> result)
        {
            if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, result);
            }

            DoConjugate(result);
        }

        /// <summary>
        /// Computes the modulus (matrix % divisor) for each element of the matrix.
        /// </summary>
        /// <param name="divisor">The scalar denominator to use.</param>
        /// <returns>A matrix containing the results.</returns>
        public Matrix<T> Modulus(T divisor)
        {
            var result = CreateMatrix(RowCount, ColumnCount);
            DoModulus(divisor, result);
            return result;
        }

        /// <summary>
        /// Computes the modulus (matrix % divisor) for each element of the matrix.
        /// </summary>
        /// <param name="divisor">The scalar denominator to use.</param>
        /// <param name="result">Matrix to store the results in.</param>
        public void Modulus(T divisor, Matrix<T> result)
        {
            if (ColumnCount != result.ColumnCount || RowCount != result.RowCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, result);
            }

            DoModulus(divisor, result);
        }

        /// <summary>
        /// Computes the modulus (dividend % matrix) for each element of the matrix.
        /// </summary>
        /// <param name="dividend">The scalar numerator to use.</param>
        /// <returns>A matrix containing the results.</returns>
        public Matrix<T> ModulusByThis(T dividend)
        {
            var result = CreateMatrix(RowCount, ColumnCount);
            DoModulusByThis(dividend, result);
            return result;
        }

        /// <summary>
        /// Computes the modulus (dividend % matrix) for each element of the matrix.
        /// </summary>
        /// <param name="dividend">The scalar numerator to use.</param>
        /// <param name="result">Matrix to store the results in.</param>
        public void ModulusByThis(T dividend, Matrix<T> result)
        {
            if (ColumnCount != result.ColumnCount || RowCount != result.RowCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, result);
            }

            DoModulusByThis(dividend, result);
        }

        /// <summary>
        /// Pointwise multiplies this matrix with another matrix.
        /// </summary>
        /// <param name="other">The matrix to pointwise multiply with this one.</param>
        /// <exception cref="ArgumentException">If this matrix and <paramref name="other"/> are not the same size.</exception>
        /// <returns>A new matrix that is the pointwise multiplication of this matrix and <paramref name="other"/>.</returns>
        public Matrix<T> PointwiseMultiply(Matrix<T> other)
        {
            if (ColumnCount != other.ColumnCount || RowCount != other.RowCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, other, "other");
            }

            var result = CreateMatrix(RowCount, ColumnCount);
            DoPointwiseMultiply(other, result);
            return result;
        }

        /// <summary>
        /// Pointwise multiplies this matrix with another matrix and stores the result into the result matrix.
        /// </summary>
        /// <param name="other">The matrix to pointwise multiply with this one.</param>
        /// <param name="result">The matrix to store the result of the pointwise multiplication.</param>
        /// <exception cref="ArgumentException">If this matrix and <paramref name="other"/> are not the same size.</exception>
        /// <exception cref="ArgumentException">If this matrix and <paramref name="result"/> are not the same size.</exception>
        public void PointwiseMultiply(Matrix<T> other, Matrix<T> result)
        {
            if (ColumnCount != result.ColumnCount || RowCount != result.RowCount || ColumnCount != other.ColumnCount || RowCount != other.RowCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, other, result);
            }

            DoPointwiseMultiply(other, result);
        }

        /// <summary>
        /// Pointwise divide this matrix by another matrix.
        /// </summary>
        /// <param name="divisor">The pointwise denominator matrix to use.</param>
        /// <exception cref="ArgumentException">If this matrix and <paramref name="divisor"/> are not the same size.</exception>
        /// <returns>A new matrix that is the pointwise division of this matrix and <paramref name="divisor"/>.</returns>
        public Matrix<T> PointwiseDivide(Matrix<T> divisor)
        {
            if (ColumnCount != divisor.ColumnCount || RowCount != divisor.RowCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, divisor);
            }

            var result = CreateMatrix(RowCount, ColumnCount);
            DoPointwiseDivide(divisor, result);
            return result;
        }

        /// <summary>
        /// Pointwise divide this matrix by another matrix and stores the result into the result matrix.
        /// </summary>
        /// <param name="divisor">The pointwise denominator matrix to use.</param>
        /// <param name="result">The matrix to store the result of the pointwise division.</param>
        /// <exception cref="ArgumentException">If this matrix and <paramref name="divisor"/> are not the same size.</exception>
        /// <exception cref="ArgumentException">If this matrix and <paramref name="result"/> are not the same size.</exception>
        public void PointwiseDivide(Matrix<T> divisor, Matrix<T> result)
        {
            if (ColumnCount != result.ColumnCount || RowCount != result.RowCount || ColumnCount != divisor.ColumnCount || RowCount != divisor.RowCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, divisor, result);
            }

            DoPointwiseDivide(divisor, result);
        }

        /// <summary>
        /// Pointwise modulus this matrix by another matrix.
        /// </summary>
        /// <param name="divisor">The pointwise denominator matrix to use.</param>
        /// <exception cref="ArgumentException">If this matrix and <paramref name="divisor"/> are not the same size.</exception>
        /// <returns>A new matrix that is the pointwise modulus of this matrix and <paramref name="divisor"/>.</returns>
        public Matrix<T> PointwiseModulus(Matrix<T> divisor)
        {
            if (ColumnCount != divisor.ColumnCount || RowCount != divisor.RowCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, divisor);
            }

            var result = CreateMatrix(RowCount, ColumnCount);
            DoPointwiseModulus(divisor, result);
            return result;
        }

        /// <summary>
        /// Pointwise modulus this matrix by another matrix and stores the result into the result matrix.
        /// </summary>
        /// <param name="divisor">The pointwise denominator matrix to use.</param>
        /// <param name="result">The matrix to store the result of the pointwise modulus.</param>
        /// <exception cref="ArgumentException">If this matrix and <paramref name="divisor"/> are not the same size.</exception>
        /// <exception cref="ArgumentException">If this matrix and <paramref name="result"/> are not the same size.</exception>
        public void PointwiseModulus(Matrix<T> divisor, Matrix<T> result)
        {
            if (ColumnCount != result.ColumnCount || RowCount != result.RowCount || ColumnCount != divisor.ColumnCount || RowCount != divisor.RowCount)
            {
                throw DimensionsDontMatch<ArgumentException>(this, divisor, result);
            }

            DoPointwiseModulus(divisor, result);
        }

        /// <summary>
        /// Computes the trace of this matrix.
        /// </summary>
        /// <returns>The trace of this matrix</returns>
        /// <exception cref="ArgumentException">If the matrix is not square</exception>
        public abstract T Trace();

        /// <summary>
        /// Calculates the rank of the matrix
        /// </summary>
        /// <returns>effective numerical rank, obtained from SVD</returns>
        public virtual int Rank()
        {
            return Svd<T>.Create(this, false).Rank;
        }

        /// <summary>Calculates the condition number of this matrix.</summary>
        /// <returns>The condition number of the matrix.</returns>
        /// <remarks>The condition number is calculated using singular value decomposition.</remarks>
        public virtual T ConditionNumber()
        {
            return Svd<T>.Create(this, false).ConditionNumber;
        }

        /// <summary>Computes the determinant of this matrix.</summary>
        /// <returns>The determinant of this matrix.</returns>
        public virtual T Determinant()
        {
            if (RowCount != ColumnCount)
            {
                throw new ArgumentException(Resources.ArgumentMatrixSquare);
            }

            return LU<T>.Create(this).Determinant;
        }

        /// <summary>Computes the inverse of this matrix.</summary>
        /// <returns>The inverse of this matrix.</returns>
        public virtual Matrix<T> Inverse()
        {
            if (RowCount != ColumnCount)
            {
                throw new ArgumentException(Resources.ArgumentMatrixSquare);
            }

            return LU<T>.Create(this).Inverse();
        }

        /// <summary>
        /// Computes the Kronecker product of this matrix with the given matrix. The new matrix is M-by-N
        /// with M = this.Rows * lower.Rows and N = this.Columns * lower.Columns.
        /// </summary>
        /// <param name="other">The other matrix.</param>
        /// <returns>The kronecker product of the two matrices.</returns>
        public virtual Matrix<T> KroneckerProduct(Matrix<T> other)
        {
            var result = CreateMatrix(RowCount*other.RowCount, ColumnCount*other.ColumnCount);
            KroneckerProduct(other, result);
            return result;
        }

        /// <summary>
        /// Computes the Kronecker product of this matrix with the given matrix. The new matrix is M-by-N
        /// with M = this.Rows * lower.Rows and N = this.Columns * lower.Columns.
        /// </summary>
        /// <param name="other">The other matrix.</param>
        /// <param name="result">The kronecker product of the two matrices.</param>
        /// <exception cref="ArgumentException">If the result matrix's dimensions are not (this.Rows * lower.rows) x (this.Columns * lower.Columns).</exception>
        public virtual void KroneckerProduct(Matrix<T> other, Matrix<T> result)
        {
            if (result.RowCount != (RowCount*other.RowCount) || result.ColumnCount != (ColumnCount*other.ColumnCount))
            {
                throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, other, result);
            }

            for (var j = 0; j < ColumnCount; j++)
            {
                for (var i = 0; i < RowCount; i++)
                {
                    result.SetSubMatrix(i*other.RowCount, other.RowCount, j*other.ColumnCount, other.ColumnCount, At(i, j)*other);
                }
            }
        }

        /// <summary>
        /// Normalizes the columns of a matrix.
        /// </summary>
        /// <param name="p">The norm under which to normalize the columns under.</param>
        /// <returns>A normalized version of the matrix.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the parameter p is not positive.</exception>
        public virtual Matrix<T> NormalizeColumns(int p)
        {
            if (p < 1)
            {
                throw new ArgumentOutOfRangeException("p", Resources.ArgumentMustBePositive);
            }

            var ret = Clone();

            for (var index = 0; index < ColumnCount; index++)
            {
                ret.SetColumn(index, Column(index).Normalize(p));
            }

            return ret;
        }

        /// <summary>
        /// Normalizes the rows of a matrix.
        /// </summary>
        /// <param name="p">The norm under which to normalize the rows under.</param>
        /// <returns>A normalized version of the matrix.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the parameter p is not positive.</exception>
        public virtual Matrix<T> NormalizeRows(int p)
        {
            if (p < 1)
            {
                throw new ArgumentOutOfRangeException("p", Resources.ArgumentMustBePositive);
            }

            var ret = Clone();

            for (var index = 0; index < RowCount; index++)
            {
                ret.SetRow(index, Row(index).Normalize(p));
            }

            return ret;
        }

        #region Exceptions - possibly move elsewhere?

        public static Exception DimensionsDontMatch<TException>(Matrix<T> left, Matrix<T> right, Matrix<T> result, string paramName = null)
            where TException : Exception
        {
            var message = string.Format(Resources.ArgumentMatrixDimensions3, left.RowCount + "x" + left.ColumnCount, right.RowCount + "x" + right.ColumnCount, result.RowCount + "x" + result.ColumnCount);
            return CreateException<TException>(message, paramName);
        }

        public static Exception DimensionsDontMatch<TException>(Matrix<T> left, Matrix<T> right, string paramName = null)
            where TException : Exception
        {
            var message = string.Format(Resources.ArgumentMatrixDimensions2, left.RowCount + "x" + left.ColumnCount, right.RowCount + "x" + right.ColumnCount);
            return CreateException<TException>(message, paramName);
        }

        public static Exception DimensionsDontMatch<TException>(Matrix<T> matrix)
            where TException : Exception
        {
            var message = string.Format(Resources.ArgumentMatrixDimensions1, matrix.RowCount + "x" + matrix.ColumnCount);
            return CreateException<TException>(message);
        }

        public static Exception DimensionsDontMatch<TException>(Matrix<T> left, Vector<T> right, Vector<T> result, string paramName = null)
            where TException : Exception
        {
            return DimensionsDontMatch<TException>(left, right.ToColumnMatrix(), result.ToColumnMatrix(), paramName);
        }

        public static Exception DimensionsDontMatch<TException>(Matrix<T> left, Vector<T> right, string paramName = null)
            where TException : Exception
        {
            return DimensionsDontMatch<TException>(left, right.ToColumnMatrix(), paramName);
        }

        public static Exception DimensionsDontMatch<TException>(Vector<T> left, Matrix<T> right, string paramName = null)
            where TException : Exception
        {
            return DimensionsDontMatch<TException>(left.ToColumnMatrix(), right, paramName);
        }

        public static Exception DimensionsDontMatch<TException>(Vector<T> left, Vector<T> right, string paramName = null)
            where TException : Exception
        {
            return DimensionsDontMatch<TException>(left.ToColumnMatrix(), right.ToColumnMatrix(), paramName);
        }

        static Exception CreateException<TException>(string message, string paramName = null)
            where TException : Exception
        {
            if (typeof (TException) == typeof (ArgumentException))
            {
                return new ArgumentException(message, paramName);
            }
            if (typeof (TException) == typeof (ArgumentOutOfRangeException))
            {
                return new ArgumentOutOfRangeException(paramName, message);
            }
            return new Exception(message);
        }

        #endregion
    }
}
